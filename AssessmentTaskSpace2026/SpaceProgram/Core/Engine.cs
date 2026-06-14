namespace SpaceProgram.Core;

using Interfaces;
using IO.Interfaces;
using Models.Interfaces;
using Services.Interfaces;
using Rendering.Interfaces;
using Utilities.Interfaces;

using IO.Enums;
using Services.Models;
using GCommon.Exceptions;

using static GCommon.Constants.Messages;
using static GCommon.Constants.ApplicationConstants;
using static GCommon.Validations.DimensionValidator;
using static GCommon.Validations.EmailValidator;

public class Engine : IEngine
{
    private readonly IReader _reader;
    private readonly IWriter _writer;
    private readonly IMapGenerator _mapGenerator;
    private readonly IMissionService _missionService;
    private readonly IMapRenderer _mapRenderer;
    private readonly IConsoleKey _consoleKey;
    private readonly IAmbience _ambience;
    private readonly IEmailSender _emailSender;

    public Engine(IWriter writer, IReader reader,
                  IMapGenerator mapGenerator, 
                  IMissionService missionService, 
                  IMapRenderer mapRenderer, 
                  IConsoleKey consoleKey, 
                  IAmbience ambience,
                  IEmailSender emailSender)
    {
        _writer = writer;
        _reader = reader;
        _mapGenerator = mapGenerator;
        _missionService = missionService;
        _mapRenderer = mapRenderer;
        _consoleKey = consoleKey;
        _ambience = ambience;
        _emailSender = emailSender;
    }

    public async Task RunAsync()
    {
        ICosmicMap map = InitializeGame();

        MissionReport report = _missionService.ProcessMissions(map);
        string renderedMap = _mapRenderer.Render(map, report);
        _writer.WriteLine(renderedMap);
        
        await AskForEmailAsync(renderedMap);
        await WaitForRestartAsync();
    }
    
    private ICosmicMap InitializeGame()
    {
        _writer.Clear();
        _writer.WriteLine(WelcomeMessage);
        int rows = ReadValidDimension(RowName);
        int columns = ReadValidDimension(ColumnName);

        ICosmicMap map = _mapGenerator.GenerateMap(rows, columns);
        string renderedMap = _mapRenderer.Render(map);

        _writer.WriteLine();
        _writer.WriteLine(ReadyToUseMapMessage);
        _writer.WriteLine(renderedMap);

        return map;
    }

    private int ReadValidDimension(string dimensionName)
    {
        while (true)
        {
            _writer.Write(string.Format(MapPrompt, dimensionName));

            string? input = _reader.ReadLine();

            try
            {
                int dimension = ValidateDimension(input, dimensionName);
                return dimension;
            }
            catch (NullInputException ne)
            {
                _writer.Write(ne.Message);
            }
            catch (InvalidInputException iie)
            {
                _writer.Write(iie.Message);
            }
            catch (Exception)
            {
                _writer.WriteLine(string.Format(SomethingWrongWithMapMessage, MinSize, MaxSize));
            }
        }
    }
    
    private async Task AskForEmailAsync(string renderedMap)
    {
        _writer.Write(WantEmailMessage);

        UserCommand command = _consoleKey.ReadEmailKey();
        _writer.WriteLine(string.Empty);
        
        if (command != UserCommand.Yes)
            return;

        await SendEmailAsync(renderedMap);
    }

    private async Task SendEmailAsync(string renderedMap)
    {
        string senderEmail = ReadValidInput(WriteYourEmailMessage, ValidateSenderEmail);
        string appPassword = ReadValidInput(WriteYourPasswordMessage, ValidateAppPassword);
        string receiverEmail = ReadValidInput(WriteEmailReceiverMessage, ValidateReceiverEmail);
        string subject = ReadValidInput(EmailSubjectMessage, ValidateSubject);

        try
        {
            bool isSent = await _emailSender.SendGmailAsync(
                [senderEmail, appPassword],
                receiverEmail,
                subject,
                body: renderedMap);
            
            _writer.WriteLine(isSent
                ? EmailSendSuccessMessage
                : EmailWentWrongMessage);
        }
        catch (EmailSendingException ese)
        {
            _writer.WriteLine(ese.Message);
        }
    }
    
    private async Task WaitForRestartAsync()
    {
        _writer.WriteLine(TryNewGameMessage);

        UserCommand keyInfo = _consoleKey.ReadRestartKey();
        if (keyInfo == UserCommand.Exit)
        {
            _writer.WriteLine(QuitMessage);
            _ambience.Exit();
            return;
        }
        
        await RunAsync();
    }
    
    private string ReadValidInput(string message, Action<string?> validate)
    {
        while (true)
        {
            try
            {
                _writer.Write(message);
                string? input = _reader.ReadLine();

                validate(input);

                return input!;
            }
            catch (EmailInputException eie)
            {
                _writer.WriteLine(eie.Message);
            }
            catch (NullInputException ne)
            {
                _writer.WriteLine(ne.Message);
            }
            catch (Exception)
            {
                _writer.WriteLine(EmailWentWrongMessage);
            }
        }
    }
}

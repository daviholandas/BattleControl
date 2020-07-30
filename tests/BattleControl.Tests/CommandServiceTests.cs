using System.Collections.ObjectModel;
using System.Text;
using Xunit;

namespace BattleControl.Tests
{
    public class CommandServiceTests
    {
        [Fact]
        public void CommandService_CommandMustBeReceiveArgumentAndDoExecuteAndSendResponse()
        {
            //Arrange
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript("pwd");
            pipeline.Commands.Add("Out-String");
            Collection<PSObject> results = pipeline.Invoke();
            runspace.Close();
            //Act

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var result in results)
                stringBuilder.AppendLine(result.ToString());
            var resultCommand = stringBuilder.ToString();
            var expected = "D://BattleControl";
            //Assert
            Assert.Equal(expected, resultCommand);
        }
    }
}
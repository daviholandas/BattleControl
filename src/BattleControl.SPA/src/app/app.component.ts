import { Component, OnInit } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';
import { MachineClientInformation } from './interfaces/machineClientInformation';
import { CommandService } from './services/command.service';
import { Command } from './interfaces/command';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  private hubConnection: HubConnection;
  machineClientInformation: MachineClientInformation;
  response:string;
  command:Command = {argument: ""};

  constructor(private commandService: CommandService){
    this.hubConnection = new HubConnectionBuilder()
    .withUrl("http://localhost:49175/commands")
    .withAutomaticReconnect()
    .build();

    this.hubConnection
    .start()
    .then(_ => console.log("Connection succeded!"))
    .catch(e => console.log(e));
  }
 
  sendInputCommand(){
    this.commandService.send(this.command).subscribe(value => console.log(value));
  }
  ngOnInit(): void {
    this.hubConnection.on('ReceiveResponseCommand', (responseData) =>{
      console.log(responseData);
      this.response = responseData
    });
    this.hubConnection.on('SendInfoClientMachine', (info, user) =>{
      console.log(info, user);
       this.machineClientInformation = info
      });

  }

}

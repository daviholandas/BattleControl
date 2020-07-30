import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Command } from '../interfaces/command';


@Injectable({
  providedIn: 'root'
})
export class CommandService {

  constructor(private http: HttpClient) { }

  send(command: Command){
    return this.http.post<Command>("http://localhost:49175/api/v1/commands", command);
  }

}
  
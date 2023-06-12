import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SenderService {

  public login: string;
  public password: string;
  public logged: boolean;
  constructor() { 
    this.login='';
    this.password='';
    this.logged=false;
  }
}

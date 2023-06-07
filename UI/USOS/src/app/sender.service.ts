import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SenderService {

  public login: string;
  public password: string;
  constructor() { 
    this.login='';
    this.password='';
  }
}

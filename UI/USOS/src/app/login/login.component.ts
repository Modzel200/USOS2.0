import { Component, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from './models/login.model';
import { SenderService } from '../sender.service';
@Component({ templateUrl: 'login.component.html', styleUrls: ['./login.component.css'] })
@Injectable()
export class LoginComponent{
    public account: Login;
    public login: string;
    public password: string;
    constructor(private router: Router, private senderService: SenderService) { 
        this.account = {
            login: '',
            password: ''
        };
        this.login = '';
        this.password = '';
    }
    
    redirect() {
        this.senderService.login = this.login;
        this.senderService.password = this.password;
        this.router.navigate(['/home']);
    }
    onSubmit() {
    console.log(this.login,this.password);
    this.redirect();
    }

}
import { Component, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from './models/login.model';
import { SenderService } from '../sender.service';
import { LoginService } from './service/login.service';
@Component({ templateUrl: 'login.component.html'})
@Injectable()
export class LoginComponent{
    public account: Login;
    public login: string;
    public password: string;
    constructor(private router: Router, private senderService: SenderService, private loginService: LoginService) { 
        this.account = {
            username: '',
            password: ''
        };
        this.login = '';
        this.password = '';
    }
    
    redirect() {
        if(this.senderService.logged)
        {
            this.router.navigate(['/home']);
        }
        else{
            alert("Zły login lub hasło!");
        }
    }
    onSubmit() {
    console.log(this.login,this.password);
    this.account.username = this.login;
    this.account.password = this.password;
    this.loginService.login(this.account).subscribe(
        response =>{
            console.log(response);
            this.senderService.logged = response;
            this.redirect();
        }
    );
    }

}
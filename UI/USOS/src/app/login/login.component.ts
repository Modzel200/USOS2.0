import { Component, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from './models/login.model';
@Component({ templateUrl: 'login.component.html', styleUrls: ['./login.component.css'] })
@Injectable()
export class LoginComponent{
    public account: Login;
    constructor(private router: Router) { 
        this.account = {
            login: '',
            password: ''
        };
    }
    
    redirect() {
        this.router.navigate(['/home']);
    }
    onSubmit() {
    console.log(this.account);
    this.redirect();
    }

}
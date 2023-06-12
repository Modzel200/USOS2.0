import { Component} from '@angular/core';
import { User } from './models/user.component';
import { UserService } from './service/user.service';
@Component({ templateUrl: 'user.component.html', styleUrls: ['./user.component.css']})
export class UserComponent  {
    title = 'USOS';
    user: User = {
        id: '',
        login: '',
        password: '',
        confirmPassword: '',
        type: ''
}
    constructor(private userService: UserService) { 
    }
    onSubmit() {
        if(this.user.password==this.user.confirmPassword)
        {

        }
        else
        {
            alert("Passwords are not the same!");
        }
    }
}

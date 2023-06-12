import { Component} from '@angular/core';
import { User } from './models/user.component';
import { UserService } from './service/user.service';
import { Admin } from './models/admin.component';
@Component({ templateUrl: 'user.component.html', styleUrls: ['./user.component.css']})
export class UserComponent  {
    title = 'USOS';
    user: User = {
        id: '',
        nickname: '',
        login: '',
        password: '',
        confirmPassword: '',
}
    admin: Admin = {
        id: '',
        nickname: '',
        username: '',
        password: '',
    }
    constructor(private userService: UserService) { 
    }
    onSubmit() {
        if(this.user.password==this.user.confirmPassword)
        {
            this.admin.nickname=this.user.nickname;
            this.admin.username=this.user.login;
            this.admin.password=this.user.password;
            this.userService.createUser(this.admin).subscribe(
                response => {
                    console.log(response);
                    this.user= {
                        id: '',
                        nickname: '',
                        login: '',
                        password: '',
                        confirmPassword: '',
                    }
                }
            );
            alert("Konto stworzone!");
        }
        else
        {
            alert("Passwords are not the same!");
        }
    }
}

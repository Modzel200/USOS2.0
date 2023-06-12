import { Component } from '@angular/core';
import { StudentService } from './student/service/student.service';
import { Student } from './student/models/student.model';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{

}

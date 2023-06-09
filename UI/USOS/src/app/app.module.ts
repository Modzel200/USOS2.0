import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'; 
import { appRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

import { HomeComponent } from './home';
import { StudentComponent } from './student';
import { LecturerComponent } from './lecturer';
import { LoginComponent } from './login';
import { SubjectComponent } from './subject';
import { LayoutComponent } from './layout';
import { majorSubjectComponent } from './majorSubject';
import { UserComponent } from './User';
import { CookieService } from 'ngx-cookie-service';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    StudentComponent,
    LecturerComponent,
    LoginComponent,
    SubjectComponent,
    LayoutComponent,
    majorSubjectComponent,
    UserComponent
  ],
  imports: [
    FormsModule,
    BrowserModule,
    appRoutingModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }

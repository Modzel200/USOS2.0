import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser'

import { HomeComponent } from './home';
import { StudentComponent } from './student';
import { LecturerComponent } from './lecturer';
import { LoginComponent } from './login';
import { SubjectComponent } from './subject';
const routes: Routes = [
    { path: '', component: LoginComponent },
    { path: 'student', component: StudentComponent },
    { path: 'lecturer', component: LecturerComponent },
    { path: 'home', component: HomeComponent},
    { path: 'subject', component: SubjectComponent},
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const appRoutingModule = RouterModule.forRoot(routes);
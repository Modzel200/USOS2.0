import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser'

import { HomeComponent } from './home';
import { StudentComponent } from './student';
import { LecturerComponent } from './lecturer';
import { LoginComponent } from './login';
import { SubjectComponent } from './subject';
import { LayoutComponent } from './layout';
const routes: Routes = [
    {
        path: '', 
        component: LayoutComponent,
        children: [
            { path: 'student', component: StudentComponent },
            { path: 'lecturer', component: LecturerComponent },
            { path: 'home', component: HomeComponent},
            { path: 'subject', component: SubjectComponent}
        ]
    },
    { path: 'login', component: LoginComponent },
    
    // otherwise redirect to home
    //{ path: '**', redirectTo: 'login' }
];

export const appRoutingModule = RouterModule.forRoot(routes);
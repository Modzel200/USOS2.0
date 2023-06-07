import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser'

import { HomeComponent } from './home';
import { StudentComponent } from './student';
import { LecturerComponent } from './lecturer';
import { LoginComponent } from './login';
import { SubjectComponent } from './subject';
import { LayoutComponent } from './layout';
import { majorSubjectComponent } from './majorSubject';
const routes: Routes = [
    {
        path: '', 
        component: LayoutComponent,
        children: [
            { path: 'student', component: StudentComponent },
            { path: 'lecturer', component: LecturerComponent },
            { path: 'home', component: HomeComponent},
            { path: 'subject', component: SubjectComponent},
            { path: 'majorSubject', component: majorSubjectComponent}
        ]
    },
    { path: 'login', component: LoginComponent },
    
    // otherwise redirect to home
    //{ path: '**', redirectTo: 'login' }
];

export const appRoutingModule = RouterModule.forRoot(routes);
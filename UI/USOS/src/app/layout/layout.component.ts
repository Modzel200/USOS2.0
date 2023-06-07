import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SenderService } from '../sender.service';


@Component({
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent{
  constructor(private router: Router, private senderService: SenderService) {}
  redirectToStudents(){
    if(this.senderService.login==='admin' || this.senderService.password==='admin'){
    this.router.navigate(['/student']);
    }
    else{
      console.log("You are not a student!");
      this.router.navigate(['/login']);
    }
  }
  redirectToLecturer()
  {
    if(this.senderService.login==='admin' || this.senderService.password==='admin'){
      this.router.navigate(['/lecturer']);
      }
      else{
        console.log("You are not a lecturer!");
        this.router.navigate(['/login']);
      }
  }
  redirectToSubjects()
  {
    if(this.senderService.login==='admin' || this.senderService.password==='admin'){
      this.router.navigate(['/subject']);
      }
      else{
        console.log("You are not a admin!");
        this.router.navigate(['/login']);
      }
  }
}
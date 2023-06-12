import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SenderService } from '../sender.service';
import { CookieService } from 'ngx-cookie-service';


@Component({
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent{
  private cookie_name="";
  private all_cookies:any="";
  home1=true;
  home2=false;
  students1=true;
  students2=false;
  lecturer1=true;
  lecturer2=false;
  subjects1=true;
  subjects2=false;
  major1=true;
  major2=false;
  user1=true;
  user2=false;
  lang=true;
  lang2=true;
  constructor(private router: Router, private senderService: SenderService, private cookieService: CookieService) {}
  redirectToStudents(){
    if(this.senderService.login==='admin' || this.senderService.password==='admin'){
    this.router.navigate(['/student']);
    this.students1=false;
    this.students2=true;
    this.home1=true;
    this.home2=false;
    this.lecturer1=true;
    this.lecturer2=false;
    this.subjects1=true;
    this.subjects2=false;
    this.major1=true;
    this.major2=false;
    this.user1=true;
    this.user2=false;
    }
    else{
      console.log("You are not a student!");
      alert("Nie jesteś zalogowany!");
      //this.router.navigate(['/login']);
    }
  }
  redirectToLecturer()
  {
    if(this.senderService.login==='admin' || this.senderService.password==='admin'){
      this.router.navigate(['/lecturer']);
      this.students1=true;
      this.students2=false;
      this.home1=true;
      this.home2=false;
      this.lecturer1=false;
      this.lecturer2=true;
      this.subjects1=true;
      this.subjects2=false;
      this.major1=true;
      this.major2=false;
      this.user1=true;
      this.user2=false;
      }
      else{
        console.log("You are not a lecturer!");
        alert("Nie jesteś zalogowany!");
        //this.router.navigate(['/login']);
      }
  }
  redirectToSubjects()
  {
    if(this.senderService.login==='admin' || this.senderService.password==='admin'){
      this.router.navigate(['/subject']);
      this.students1=true;
      this.students2=false;
      this.home1=true;
      this.home2=false;
      this.lecturer1=true;
      this.lecturer2=false;
      this.subjects1=false;
      this.subjects2=true;
      this.major1=true;
      this.major2=false;
      this.user1=true;
      this.user2=false;
      }
      else{
        console.log("You are not a admin!");
        alert("Nie jesteś zalogowany!");
        //this.router.navigate(['/login']);
      }
  }
  redirectToMajors()
  {
    if(this.senderService.login==='admin' || this.senderService.password==='admin'){
      this.router.navigate(['/majorSubject']);
      this.students1=true;
      this.students2=false;
      this.home1=true;
      this.home2=false;
      this.lecturer1=true;
      this.lecturer2=false;
      this.subjects1=true;
      this.subjects2=false;
      this.major1=false;
      this.major2=true;
      this.user1=true;
      this.user2=false;
      }
      else{
        console.log("You are not a admin!");
        alert("Nie jesteś zalogowany!");
        //this.router.navigate(['/login']);
      }
  }
  redirectToHome()
  {
    this.router.navigate(['/home']);
    this.students1=true;
    this.students2=false;
    this.home1=false;
    this.home2=true;
    this.lecturer1=true;
    this.lecturer2=false;
    this.subjects1=true;
    this.subjects2=false;
    this.major1=true;
    this.major2=false;
    this.user1=true;
    this.user2=false;
  }
  redirectToUser()
  {
    if(this.senderService.login==='admin' || this.senderService.password==='admin'){
      this.router.navigate(['/user']);
      this.students1=true;
      this.students2=false;
      this.home1=true;
      this.home2=false;
      this.lecturer1=true;
      this.lecturer2=false;
      this.subjects1=true;
      this.subjects2=false;
      this.major1=true;
      this.major2=false;
      this.user1=false;
      this.user2=true;
      }
      else{
        console.log("You are not a admin!");
        alert("Nie jesteś zalogowany!");
        //this.router.navigate(['/login']);
      }
  }
  setCookie(){
    this.cookieService.set("language","Hello World");
  }
  CookiePolish()
  {
    this.cookieService.set("language","Polish");
    this.cookie_name=this.cookieService.get("language");
    console.log(this.cookie_name);
    if(this.cookie_name==="Polish")
    {
      this.lang=false;
      this.lang2=true;
    }
    else{
      this.lang=true;
      this.lang2=false;
    }
  }
  CookieEnglish()
  {
    this.cookieService.set("language","English");
    this.cookie_name=this.cookieService.get("language");
    console.log(this.cookie_name);
    if(this.cookie_name==="Polish")
    {
      this.lang=false;
      this.lang2=true;
    }
    else{
      this.lang=true;
      this.lang2=false;
    }
  }
  deleteCookie(){
    this.cookieService.delete("language");
  }
  deleteAll(){
    this.cookieService.deleteAll();
  }
  ngOnInit(): void{
    this.cookie_name=this.cookieService.get("language");
    this.all_cookies=this.cookieService.getAll();
    if(this.cookie_name==="Polish")
    {
      this.lang=false;
      this.lang2=true;
    }
    else{
      this.lang=true;
      this.lang2=false;
    }
  }
}
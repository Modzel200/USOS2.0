import { Component, OnInit } from '@angular/core';
import { Lecturer } from './models/lecturer.model';
import { LecturerService } from './service/lecturer.service';
import { Router } from '@angular/router';
@Component({ templateUrl: 'lecturer.component.html', styleUrls: ['./lecturer.component.css'] })
export class LecturerComponent implements OnInit {
    title = 'USOS';
    lecturers: Lecturer[] = [];
    lecturer: Lecturer = {
        lecturerID: '',
        name: '',
        surname: '',
        academicTitle: ''
    }
    lecturerInfo: Lecturer = {
        lecturerID: '',
        name: '',
        surname: '',
        academicTitle: ''
    }
    subjects: string[] = [];
    profSubjects: string[] = [];
    constructor(private lecturerService: LecturerService, private router: Router) {

    }
    ngOnInit(): void {
        this.getAllLecturers();
        this.getAllSubjects();
    }
    getAllLecturers() {
        this.lecturerService.getAllLecturers().subscribe(
            response => {
                this.lecturers = response;
                console.log(response);
            }
        );
    }
    getAllSubjects() {
        this.lecturerService.getAllSubjects().subscribe(
            response => {
                this.subjects = response;
                console.log(response);
            }
        );
    }
    onSubmit() {
        if(this.lecturer.lecturerID==='')
        {
        this.lecturerService.addLecturer(this.lecturer).subscribe(
            response => {
              console.log(response);  
              this.getAllLecturers();
              this.lecturer= {
                lecturerID: '',
                name: '',
                surname: '',
                academicTitle: ''
              };
            }
          );
        }else{
            this.updateLecturer(this.lecturer);
        }
    }
    deleteLecturer(id: string) {
        this.lecturerService.delLecturer(id)
        .subscribe(
            response=>{
            this.getAllLecturers();
            }
        );
    }
    populateForm(lecturer: Lecturer){
        this.lecturer = lecturer;
        console.log(this.lecturer);
        }
        updateLecturer(lecturer: Lecturer)
        {
        console.log(lecturer);
        this.lecturerService.updateLecturer(lecturer)
        .subscribe(
            response=>{
            this.getAllLecturers()
            this.lecturer= {
                lecturerID: '',
                name: '',
                surname: '',
                academicTitle: ''
              };
              }
            )
        }
    moreInfo(lecturer: Lecturer){
        this.lecturerInfo.lecturerID=lecturer.lecturerID,
        this.lecturerInfo.name= lecturer.name,
        this.lecturerInfo.surname= lecturer.surname,
        this.lecturerInfo.academicTitle= lecturer.academicTitle;
        this.getHisSubjects(lecturer.lecturerID);
        console.log(this.profSubjects);
    }
    getHisSubjects(lecturerID: string){
        this.lecturerService.getHisSubjects(lecturerID).subscribe(
            response => {
                this.profSubjects = response;
                console.log(response);
            }
        );
    }
    addToProfSubjects(e: any, subject: string){
        if(e.target.checked){
            if(!this.profSubjects.includes(subject))
            {
            this.profSubjects.push(subject);
            console.log(this.profSubjects);
            }
            else{
                this.profSubjects.splice(this.profSubjects.indexOf(subject),1);
            }
    }
    else{
        this.profSubjects.splice(this.profSubjects.indexOf(subject),1);
        console.log(this.profSubjects);
    }
    }
    addSubjectsToLecturer(){
        this.lecturerService.addSubjectsToLecturer(this.lecturerInfo.lecturerID,this.profSubjects).subscribe(
            response => {
              console.log(response);
            }
          );
          this.lecturerInfo = {
            lecturerID: '',
            name: '',
            surname: '',
            academicTitle: ''
        }
        this.profSubjects = [];
    }
}
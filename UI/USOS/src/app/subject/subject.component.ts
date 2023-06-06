import { Component, OnInit } from '@angular/core';
import { Subject } from './models/subject.model';
import { SubjectService } from './service/subject.service';
@Component({ templateUrl: 'subject.component.html', styleUrls: ['./subject.component.css'] })
export class SubjectComponent implements OnInit  {
    title = 'USOS';
    subjects: Subject[] = [];
    subject: Subject = {
        id: '',
        name: '',
        shortDesc: '',
        semester: ''
    }
    constructor(private subjectService: SubjectService) {
    }
    ngOnInit(): void {
        this.getAllSubjects();
    }
    getAllSubjects() {
        this.subjectService.getAllSubjects().subscribe(
            response => {
                this.subjects = response;
                console.log(response);
            }
        );
    }
    onSubmit() {
        if(this.subject.id==='')
        {
        this.subjectService.addSubject(this.subject).subscribe(
            response => {
              this.getAllSubjects();
              this.subject= {
                id: '',
                name: '',
                shortDesc: '',
                semester: ''
              };
            }
          );
        }else{
            this.updateSubject(this.subject);
        }
    }
    deleteSubject(id: string) {
        this.subjectService.delSubject(id)
        .subscribe(
            response=>{
            this.getAllSubjects();
            }
        );
    }
    populateForm(subject: Subject){
        this.subject = subject;
        }
        updateSubject(subject: Subject)
        {
        this.subjectService.updateSubject(subject)
        .subscribe(
            response=>{
                this.getAllSubjects()
                this.subject= {
                    id: '',
                    name: '',
                    shortDesc: '',
                    semester: ''
                    };
                }
        )
        }
}
import { Component, OnInit} from '@angular/core';
import { SenderService } from '../sender.service';
@Component({ templateUrl: 'home.component.html', styleUrls: ['./home.component.css'] })
export class HomeComponent implements OnInit{
    constructor(private senderService: SenderService) {
    }
    ngOnInit(): void {
        console.log(this.senderService.login);
    }
}

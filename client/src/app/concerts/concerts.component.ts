import { Component, OnInit } from "@angular/core";
import { Concert } from "../shared/models/concert";
import { ConcertsService } from "./concerts.service";

@Component({
    selector: 'app-concerts',
    templateUrl: './concerts.component.html',
    styleUrls: ['./concerts.component.scss']
})

export class ConcertsComponent implements OnInit {

    concerts: Concert[] = [];
    totalCount: number = 1;

    constructor(private concertsService: ConcertsService){}

    ngOnInit(): void {
        
        console.log('concerts module');

        this.getConcerts();
    }

    getConcerts(){

        console.log('concerts module inside get concerts');

        this.concertsService.getConcerts().subscribe(concertsData => {
            this.concerts = concertsData;

            this.concerts.forEach(concert => {
                concert.date = new Date(concert.date);
              });
        });
    }
}
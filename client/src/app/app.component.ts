import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {

  title = 'client';
  concerts: any[] = [];

  constructor(private http: HttpClient){}

  ngOnInit(): void {
    this.http.get('https://localhost:7048/api/concerts')
      .subscribe({
        next: (response: any) => { 
          console.log(response);
          this.concerts = response
        },
        error: error => console.log(error),
        complete: () => {
          console.log('Request completed');
        }
      });            
  }
}

import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../shared/home.service';
import { apiUrl } from '../config/apiUrl';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(
    private hService: HomeService,
    private http: HttpClient
  ) { 
    //========================get countries onload========================
    this.hService.getCountry()
    .subscribe(
      (data: any) => {
        console.log("data-response", data);
      },
      error => {
        console.log("err",error);
      }
    );

  }

  ngOnInit() {

  }

}

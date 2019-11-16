import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { apiUrl } from '../app/config/apiUrl';
import { States } from '../app/core/statesInterface';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http: HttpClient) {}

  getCountry(){
      return this.http.get(apiUrl.baseUrl+apiUrl.getCountry);
  }

  getStates(){
      return this.http.get(apiUrl.baseUrl+apiUrl.getStates);
  }
}

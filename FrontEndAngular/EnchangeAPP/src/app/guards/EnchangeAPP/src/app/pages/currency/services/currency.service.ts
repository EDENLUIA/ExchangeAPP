import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Currency } from '../models/currency.model';
import { CurrencySave } from '../models/currencySave.model';

@Injectable()
export class CurrencyService {
  urlService: string;
  constructor(private httpClient: HttpClient) {
    this.urlService = environment.urlService;
   }

  getCurrencies(): Observable<Currency[]>
  {
    return this.httpClient.get<Currency[]>(this.urlService + 'currency/all');
  }

  addCurrency(currency:CurrencySave):Observable<CurrencySave>{
    
    console.log(currency);
    return this.httpClient.post<CurrencySave>(this.urlService + 'currency/create',currency);

  }
}

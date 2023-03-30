import { ThisReceiver } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup} from '@angular/forms'
import { MatSnackBar } from '@angular/material/snack-bar';
import { Currency } from '../models/currency.model';
import { CurrencySave } from '../models/currencySave.model';
import { CurrencyService } from '../services/currency.service';


@Component({
  selector: 'app-currency',
  templateUrl: './currency.component.html',
  styleUrls: ['./currency.component.scss']
})
export class CurrencyComponent implements OnInit {
  success: boolean = false;
  currencies: Currency[] = [];
  currencyFrom: Currency = new Currency();
  currencyTo: Currency = new Currency();

  currencyForm! : FormGroup;

  currencyObj:CurrencySave = new CurrencySave();

  constructor(
    private currencyService: CurrencyService,
    private snackBar: MatSnackBar,
    private formBuilder:FormBuilder) { }

  ngOnInit(): void {
    this.getAll();
    this.currencyForm = this.formBuilder.group({
    
      Name:[''],
      Abbreviation:[''],
      Description:['']
    })
  }


  getAll(){
    this.currencyService.getCurrencies().subscribe(data =>
      {
        console.log(data);
        this.currencies = data;

        console.log(this.currencies);
      })

    console.log(this.currencies)
  }

  createCurrency()
  {
    
    this.currencyObj.name = this.currencyForm.value.Name;
    this.currencyObj.description = this.currencyForm.value.Abbreviation;
    this.currencyObj.abbreviation = this.currencyForm.value.Description;

    this.currencyService.addCurrency(this.currencyObj).subscribe(data =>
      {
        console.log(data);
      })

    this.getAll();

  }
}

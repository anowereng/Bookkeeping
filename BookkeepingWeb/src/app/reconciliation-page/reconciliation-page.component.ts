import { Component, OnInit } from '@angular/core';
import { WebApiService } from '../web-api.service';
import { UrlService } from '../url.service';
import { ResponseModel } from '../common-model/Response.model';
import { ReconciliationViewModel, CashFlowLogsViewModel, MonthValueViewModel } from '../common-model/reconcilition-model';
import { ReconcilitionRequestModel } from '../common-model/request-model';
import { AddUpdateCashFlowLogModel } from '../common-model/save-update-reconcilition-model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-reconciliation-page',
  templateUrl: './reconciliation-page.component.html',
  styleUrls: ['./reconciliation-page.component.css']
})
export class ReconciliationPageComponent implements OnInit {

  titleIncome :string = "Income";
  addUpdateCashFlowLogs : AddUpdateCashFlowLogModel[] = [];
  model:ReconciliationViewModel;
  public loading = false;
  public isBtnEnabled = true;

  constructor(private service: WebApiService, private toastr: ToastrService) {
    this.model = new ReconciliationViewModel();
   }

  ngOnInit() {
    this.getReconcilition();
  }

  getReconcilition(){
    this.loading =  true;
    var model = this.getNewModel();

    const successCallback = (response: ResponseModel): void => {
      this.model = response.result as ReconciliationViewModel;
      this.loading =  false;
    };

    const errorCallback = (error: any): void => {
      console.log(error);
      this.loading =  false;
      this.toastr.error("Error")
    };

    model.year = "2019";

    this.service.get(UrlService.reconcialation, model).subscribe( response =>{
      successCallback(response)
    }, err => {
      errorCallback(err);
    });
  }

  getNewModel(): ReconcilitionRequestModel {
    return new ReconcilitionRequestModel();
  }

  incomeCashflowLogsToAddUpdateCashLog() {

    for (let index = 0; index < this.model.incomeCashFlowLogsData.length; index++) {
      const element = this.model.incomeCashFlowLogsData[index];

      Object.keys(element.month)
        .forEach(key => {
          const monthvalue =  element.month[key as keyof MonthValueViewModel]
          if(monthvalue > 0) {
            const logmodel: AddUpdateCashFlowLogModel = {
              cashFlowId : element.CashFlowId,
              logId: element.logId,
              typeId: element.typeId,
              year: '2019',
              month: key,
              amount: monthvalue
            }
            this.addUpdateCashFlowLogs.push(logmodel);
          }
        });
    }
  }

  expenseCashflowLogsToAddUpdateCashLog() {

    for (let index = 0; index < this.model.expenseCashFlowLogsData.length; index++) {

      const element = this.model.expenseCashFlowLogsData[index];

      Object.keys(element.month)
        .forEach(key => {
          const monthvalue =  element.month[key as keyof MonthValueViewModel]
          if(monthvalue > 0) {
            const logmodel: AddUpdateCashFlowLogModel = {
              cashFlowId : element.CashFlowId,
              logId: element.logId,
              typeId: element.typeId,
              year: '2019',
              month: key,
              amount: monthvalue
            }
            this.addUpdateCashFlowLogs.push(logmodel);
          }
        });
    }
  }

  updateAmount(monthname: string){
    this.updateReconcilitionResult(monthname);

  }

  updateReconcilitionResult(monthname: any){
    debugger;
    this.addUpdateCashFlowLogs = [];
    this.incomeCashflowLogsToAddUpdateCashLog();
    var incomeMonthvalue =  this.addUpdateCashFlowLogs.filter(x=>x.month == monthname).reduce((sum, current) => +sum  + +current.amount, 0);
    this.addUpdateCashFlowLogs = [];
    this.expenseCashflowLogsToAddUpdateCashLog();
    var expenseMonthvalue =  this.addUpdateCashFlowLogs.filter(x=>x.month == monthname).reduce((sum, current) => +sum  + +current.amount, 0);

    var m  = this.model.reconciliationResult;
    switch (monthname) {
      case 'jan':
        m.jan = incomeMonthvalue - expenseMonthvalue;
        break;
      case 'feb':
        m.feb = incomeMonthvalue - expenseMonthvalue;
        break;
      case 'mar':
        m.mar = incomeMonthvalue - expenseMonthvalue;
        break;
      case 'apr':
        m.apr = incomeMonthvalue - expenseMonthvalue;
        break;
      case 'may':
        m.may = incomeMonthvalue - expenseMonthvalue;
        break;
      case 'jun':
        m.jun = incomeMonthvalue - expenseMonthvalue;
        break;
      case 'jul':
        m.jul = incomeMonthvalue - expenseMonthvalue;
        break;
      case 'aug':
        m.aug = incomeMonthvalue - expenseMonthvalue;
        break;
      case 'sep':
        m.sep = incomeMonthvalue - expenseMonthvalue;
        break;
      case 'oct':
        m.oct = incomeMonthvalue - expenseMonthvalue;
        break;
      case 'nov':
        m.nov = incomeMonthvalue - expenseMonthvalue;
        break;
      case 'dec':
        m.dec = incomeMonthvalue - expenseMonthvalue;
        break;
      default:
        break;
    }
    this.updateFinalResult(monthname);
  }

  updateFinalResult(monthname: any) {
    var r  = this.model.result;
    var fr  = this.model.finalResult;
    var rec  = this.model.reconciliationResult;
    switch (monthname) {
      case 'jan':
        fr.jan =  rec.jan + r.jan;
        break;
      case 'feb':
        fr.feb = rec.feb + r.feb;
        break;
      case 'mar':
        fr.mar =  rec.mar + r.mar;
        break;
      case 'apr':
        fr.apr = rec.apr + r.apr;
        break;
      case 'may':
        fr.may =  rec.may + r.may;
        break;
      case 'jun':
        fr.jun = rec.jun + r.jun;
        break;
      case 'jul':
        fr.jul =  rec.jul + r.jul;
        break;
      case 'aug':
        fr.aug = rec.aug + r.aug;
        break;
      case 'sep':
        fr.sep =  rec.sep + r.sep;
        break;
      case 'oct':
        fr.oct = rec.oct + r.oct;
        break;
      case 'nov':
        fr.nov =  rec.nov + r.nov;
        break;
      case 'dec':
        fr.dec = rec.dec + r.dec;
        break;
      default:
        break;
    }
    this.cumulativeFinalResult();
  }

  cumulativeFinalResult()
  {
      var cr =  this.model.cumulativeFinalResult;
      var fr =  this.model.finalResult;

       cr.jan = fr.jan;
       cr.feb = cr.jan + fr.feb;
       cr.mar = cr.feb + fr.mar;
       cr.apr = cr.mar + fr.apr;
       cr.may = cr.apr + fr.mar;
       cr.jun = cr.may + fr.apr;
       cr.jul = cr.jun + fr.may;
       cr.aug = cr.jul + fr.jun;
       cr.sep = cr.aug + fr.jul;
       cr.oct = cr.sep + fr.aug;
       cr.nov = cr.oct + fr.sep;
       cr.dec = cr.nov + fr.oct;
       cr.dec = cr.dec + fr.nov;
  }

  saveOrUpdate() {
    this.addUpdateCashFlowLogs = [];
    this.incomeCashflowLogsToAddUpdateCashLog();
    this.expenseCashflowLogsToAddUpdateCashLog();

    this.loading =  true;
    this.isBtnEnabled =  false;

    const successCallback = (response: ResponseModel): void => {
      this.loading = false;
      this.isBtnEnabled =  true;
      this.getReconcilition();
      this.toastr.success("Updated Successfully")
    };

    const errorCallback = (error: any): void => {
      console.log(error);
      this.isBtnEnabled =  true;
      this.loading =  false;
      this.toastr.error("Error")
    };

    this.service.save(UrlService.reconcialationSaveUpdate, this.addUpdateCashFlowLogs).subscribe((response: any)=>{
      successCallback(response);
    },err=>{
      errorCallback(err)
    })
  }
}


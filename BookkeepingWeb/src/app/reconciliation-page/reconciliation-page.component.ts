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
    // this.spinnerService.show();
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

  getNewCashFlowIncomeLogsModel(): CashFlowLogsViewModel[] {
    let logs : CashFlowLogsViewModel[] = [
      {
      CashFlowId : 1 ,
      CashFlowName : 'Income',
      month: {
              jan : 12,
              feb : 12,
              mar : 0 ,
              apr : 0 ,
              may : 0 ,
              jun : 0 ,
              jul : 0 ,
              aug : 0 ,
              sep : 0 ,
              oct : 0 ,
              nov : 0 ,
              dec : 0
      },
      logId: 1,
      typeId: 1,
      typeName: 'Type1'
      },
        {
          CashFlowId : 1 ,
          CashFlowName : 'Income',
          month: {
                  jan : 12,
                  feb : 12,
                  mar : 0 ,
                  apr : 10 ,
                  may : 18 ,
                  jun : 0 ,
                  jul : 0 ,
                  aug : 0 ,
                  sep : 18 ,
                  oct : 0 ,
                  nov : 0 ,
                  dec : 0
          },
          logId: 1,
          typeId: 1,
          typeName: 'Type2'
        },
          {
            CashFlowId : 1 ,
            CashFlowName : 'Income',
            month: {
                    jan : 12,
                    feb : 12,
                    mar : 0 ,
                    apr : 10 ,
                    may : 18 ,
                    jun : 0 ,
                    jul : 0 ,
                    aug : 0 ,
                    sep : 18 ,
                    oct : 0 ,
                    nov : 0 ,
                    dec : 0
            },
            logId: 1,
            typeId: 1,
            typeName: 'Type3'
        },
  ]
  return logs
  }

  getNewCashFlowCostLogsModel(): CashFlowLogsViewModel[] {
    let logs : CashFlowLogsViewModel[] = [
      {
      CashFlowId : 1 ,
      CashFlowName : 'Expense',
      month: {
              jan : 12,
              feb : 12,
              mar : 0 ,
              apr : 0 ,
              may : 0 ,
              jun : 0 ,
              jul : 0 ,
              aug : 0 ,
              sep : 0 ,
              oct : 0 ,
              nov : 0 ,
              dec : 0
      },
      logId: 1,
      typeId: 1,
      typeName: 'Type1'
      },
        {
          CashFlowId : 1 ,
          CashFlowName : 'Expense',
          month: {
                  jan : 12,
                  feb : 12,
                  mar : 0 ,
                  apr : 10 ,
                  may : 18 ,
                  jun : 0 ,
                  jul : 0 ,
                  aug : 0 ,
                  sep : 18 ,
                  oct : 0 ,
                  nov : 0 ,
                  dec : 0
          },
          logId: 1,
          typeId: 1,
          typeName: 'Type2'
        },
          {
            CashFlowId : 1 ,
            CashFlowName : 'Expense',
            month: {
                    jan : 12,
                    feb : 12,
                    mar : 0 ,
                    apr : 10 ,
                    may : 18 ,
                    jun : 0 ,
                    jul : 0 ,
                    aug : 0 ,
                    sep : 18 ,
                    oct : 0 ,
                    nov : 0 ,
                    dec : 0
            },
            logId: 1,
            typeId: 1,
            typeName: 'Type3'
        },
  ]
  return logs
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

  saveOrUpdate() {
    this.addUpdateCashFlowLogs = [];
    this.incomeCashflowLogsToAddUpdateCashLog();
    this.expenseCashflowLogsToAddUpdateCashLog();
    this.loading =  true;
    this.isBtnEnabled =  false;

    const successCallback = (response: ResponseModel): void => {
      this.loading = false;
      this.isBtnEnabled =  true;
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


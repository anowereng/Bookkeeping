
export interface IReconciliationViewModel {
  income : MonthValueViewModel;
  expense : MonthValueViewModel;
}

export class ReconciliationViewModel implements IReconciliationViewModel {

     income : MonthValueViewModel;
     expense : MonthValueViewModel;
     cumulativeIncome : MonthValueViewModel;
     cumulativeCost : MonthValueViewModel;
     result : MonthValueViewModel;
     incomeCashFlowLogsData : CashFlowLogsViewModel[]
     expenseCashFlowLogsData : CashFlowLogsViewModel[]

  constructor() {
      this.income =  new MonthValueViewModel;
      this.expense =  new MonthValueViewModel;
      this.cumulativeIncome =  new MonthValueViewModel;
      this.cumulativeCost =  new MonthValueViewModel;
      this.result =  new MonthValueViewModel;
      this.incomeCashFlowLogsData =   [];
      this.expenseCashFlowLogsData =   [];
  }
}

  export class MonthValueViewModel
    {
         jan : number
         feb : number
         mar : number
         apr : number

         may : number
         jun : number
         jul : number
         aug : number

         sep : number
         oct : number
         nov : number
         dec : number

        constructor () {

           this.jan = 0;
           this.feb = 0;
           this.mar = 0;
           this.apr = 0;

           this.may = 0;
           this.jun = 0;
           this.jul = 0;
           this.aug = 0;

           this.sep = 0;
           this.oct = 0;
           this.nov = 0;
           this.dec = 0;
         }

  }


export class CashFlowLogsViewModel {

  typeName: string;
  month : MonthValueViewModel
  CashFlowId: number;
  CashFlowName: string;
  logId: number;
  typeId: number;
  constructor(){
    this.typeName ='';
    this.month =  new MonthValueViewModel();
    this.CashFlowId =  0;
    this.CashFlowName =  '';
    this.logId =  0;
    this.typeId =  0;

  }
}

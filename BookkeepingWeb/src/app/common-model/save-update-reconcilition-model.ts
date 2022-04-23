export class AddUpdateCashFlowLogModel {
    logId : number
    typeId : number
    cashFlowId : number
    year: string
    month: string
    amount: number
    constructor(){
      this.logId =  0;
      this.typeId =  0;
      this.cashFlowId =  0 ;
      this.year = '';
      this.month =  '';
      this.amount = 0
    }
}

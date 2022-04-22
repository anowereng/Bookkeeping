import { environment } from "src/environments/environment";

export  class  UrlService {

  static reconcialation: string =  environment.baseUrl + 'reconciliation';
  static reconcialationSaveUpdate: string = environment.baseUrl + 'reconciliation/AddOrUpdateCostLog';

}

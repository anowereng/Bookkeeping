import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResponseModel } from './common-model/Response.model';
import { UrlService } from './url.service';

@Injectable({
  providedIn: 'root'
})
export class WebApiService {

  constructor(private Http: HttpClient) {
  }

  save(url:string, model: any) {
    return this.Http.post(`${UrlService.reconcialationSaveUpdate}`, model);
  }

  get(url: string, model: any): Observable<ResponseModel> {
    return this.Http.post<ResponseModel>(`${url}`, model);
  }

  update(url:string, model: any) {
    return this.Http.post(`${environment.baseUrl + url}`, model);
  }

  delete(url: string, id: number): Observable<ResponseModel>{
    return this.Http.delete<ResponseModel>(`${environment.baseUrl + url + id}`);
  }
}

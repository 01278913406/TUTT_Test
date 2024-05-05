import { Injectable, Injector } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { catchError } from 'rxjs/operators';
import { BaseService } from '../../lib-shared/services/base.service';
import { ResponseResult } from '../../lib-shared/models/response-result';

@Injectable()
export class LeaguesService extends BaseService {
    constructor(http: HttpClient, injector: Injector) {
        super(http, injector, `${environment.apiDomain.EndPoint}/Leagues`);
    }

    GetsLeagues(key: string, offset?: number, limit?: number, sortField?: string, isAsc: boolean = false) {
        const queryString = `${this.serviceUri}/GetLeagues?key=${key}&offset=${offset}&limit=${limit}&sortField=${sortField}&isAsc=${isAsc}`;
        console.log("endpoint", queryString);
        return this.defaultGet(queryString);
    }

}

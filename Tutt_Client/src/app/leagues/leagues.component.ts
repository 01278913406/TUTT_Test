import { Component, Injector, OnInit } from "@angular/core";
import { LeaguesService } from "../lib-shared/services/leagues.service";
import { Leagues } from "../lib-shared/models/leagues";
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'da-leagues',
    templateUrl: './leagues.component.html',
    styleUrls: ['./leagues.component.scss'],
})
export class LeaguesComponent implements OnInit {

    searchModel: any = {
        key: '',
    };
    sortField = '';
    total = 0;
    page = 1;
    limit = 100;
    isAsc = false;
    dataSource: Leagues[] = [];

    constructor(
        protected _injector: Injector,
        private _leaguesService: LeaguesService,
    ) {
    }

    async ngOnInit() {
        await this.getData();
    }

    async getData() {
        this.dataSource = [];
        await this._leaguesService.GetsLeagues(
            this.searchModel.key,
            this.page,
            this.limit,
            this.sortField,
            this.isAsc,
        ).then(rs => {
            if (rs != undefined && rs.status) {
                this.dataSource = rs.data;
                this.total = rs.totalRecord;
            }
        });
    }
    async onSearch() {
        await this.getData();
    }
}
import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public items: Item[];
    public config: Config;

    constructor(http: Http, @Inject('ORIGIN_URL')originUrl: string) {
        http.get(originUrl+'/api/SampleData/TodoItems').subscribe(result => {
            this.items = result.json() as Item[];
        });

        http.get(originUrl+'/api/SampleData/Config').subscribe(result => {
            this.config = result.json() as Config;
        });
    }
}

interface Item {
    itemId: number;
    completed: boolean;
    description: string;
    deadline: Date;
}

interface Config {
    env: string;
}


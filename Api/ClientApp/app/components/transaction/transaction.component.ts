import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import * as Collections from 'typescript-collections';
import { Observable } from "rxjs";
import 'rxjs/Rx'; 

import { IntervalObservable } from "rxjs/observable/IntervalObservable";
@Component({
    selector: 'transaction',
    templateUrl: './transaction.component.html'
})
export class TransactionComponent {
    public transactions: Api.Domain.SellerTransaction[];
    private _http: Http;
    private _baseUrl: string;
    private alive: boolean;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        this._baseUrl = baseUrl;
        this._http = http;
        this.alive = true;
        this.getResults();
        setInterval(() => { if (this.alive) { this.getResults() } }, 30000);
    }

    getResults() {
        console.log("inside");
        this._http.get(this._baseUrl + 'api/transaction').subscribe(result => {
            var res = result.json() as Response<Api.Domain.SellerTransaction>;
            this.transactions = res.data;
        }, error => console.error(error));
    }
}

export class Response<T> {
    public operationResult: boolean;
    public data: [T];
}

module Api.Domain {
    export class Transaction {
        public Id: number;
        public Amount: string;
        public CreatedOn: string;
        public UpdatedOn: string;
        public Order: string;
        public Offer: string;
    }
    export class SellerTransaction {
        public Id: number;
        public Amount: string;
        public Order: string;
        public CreatedOn: string;
        public SellerId: number;
    }
    export class Seller {
        public Id: number;
        public Mdr: number;
        public CreatedOn: string;
        public UpdatedOn: string;
    }
}

module Cielo.Sdk.Domain {
    export class Order {
        public Id: string;
        public Price: number;
        public PaidAmount: number;
        public PendingAmount: number;
        public Reference: string;
        public Number: string;
        public Notes: string;
        public Status: string;
        public Items: OrderItem[];
        public Payments: Payment[];
        public CreatedAt: Date;
        public UpdatedAt: Date;
        public ReleaseDate: Date;
    }
    export class OrderItem {
        public Id: string;
        public Description: string;
        public Reference: string;
        public Details: string;
        public Sku: string;
        public Name: string;
        public UnitPrice: number;
        public Quantity: number;
        public UnitOfMeasure: string;
    }
    export class Payment {
        private Id: string;
        private ExternalId: string;
        private Description: string;
        private CieloCode: string;
        private AuthCode: string;
        private Brand: string;
        private Mask: string;
        private Terminal: string;
        private Amount: number;
        private PrimaryCode: string;
        private SecondaryCode: string;
        private ApplicationName: string;
        private RequestDate: string;
        private MerchantCode: string;
        private DiscountedAmount: number;
        private Installments: number;
        private PaymentFields: Collections.Dictionary<string, string>;
    }
}
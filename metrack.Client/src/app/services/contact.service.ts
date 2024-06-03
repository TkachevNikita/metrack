import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {IContact} from "../interfaces/contact.interface";
import {map, Observable} from "rxjs";
import {ContactModel} from "../models/contact.model";

@Injectable()
export class ContactService {
    constructor(private _http: HttpClient) { }

    public getContacts(): Observable<ContactModel[]> {
        return this.fetchContacts()
            .pipe(
                map((contacts: IContact[]) => contacts.map((contact: IContact) => new ContactModel(contact)))
            );
    }

    private fetchContacts(): Observable<IContact[]> {
        return this._http.get<IContact[]>('https://localhost:44303/api/Issues');
    }
}

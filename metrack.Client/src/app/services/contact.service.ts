import {DestroyRef, inject, Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {IContact} from "../interfaces/contact.interface";
import {BehaviorSubject, map, Observable, Subscription} from "rxjs";
import {ContactModel} from "../models/contact.model";
import {takeUntilDestroyed} from "@angular/core/rxjs-interop";

@Injectable()
export class ContactService {
    private _destroyRef: DestroyRef = inject(DestroyRef);
    private _contactsSubject = new BehaviorSubject<ContactModel[]>([]);
    public contacts$ = this._contactsSubject.asObservable();

    constructor(private _http: HttpClient) {
        this.loadContacts();
    }

    private loadContacts(): void {
        this.fetchContacts()
            .pipe(
                map((contacts: IContact[]) => contacts.map((contact: IContact) => new ContactModel(contact))),
                takeUntilDestroyed(this._destroyRef)
            )
            .subscribe(contacts => this._contactsSubject.next(contacts));
    }

    public createContact(contact: IContact): void {
        const formData = new FormData();
        formData.append('name', contact.name);
        formData.append('createdAt', contact.createdAt);
        formData.append('phone', contact.phone);
        formData.append('email', contact.email);
        formData.append('photo', contact.photo);

        this._http.post('https://158.160.103.170/api/Issues', formData)
            .pipe(takeUntilDestroyed(this._destroyRef))
            .subscribe(() => {
                this.loadContacts();
            });
    }

    public deleteContact(id: string): Subscription {
        return this._http.delete(`https://158.160.103.170/api/Issues/${id}`)
            .pipe(takeUntilDestroyed(this._destroyRef))
            .subscribe(() => {
                this.loadContacts();
            });
    }

    private fetchContacts(): Observable<IContact[]> {
        return this._http.get<IContact[]>('https://158.160.103.170/api/Issues');
    }
}

import {ChangeDetectionStrategy, Component, OnInit} from "@angular/core";
import {ContactModel} from "../../models/contact.model";
import {Observable} from "rxjs";
import {ContactService} from "../../services/contact.service";
import {
    MatCard,
    MatCardActions,
    MatCardContent,
    MatCardHeader,
    MatCardSubtitle,
    MatCardTitle
} from "@angular/material/card";
import {MatButton} from "@angular/material/button";

@Component({
    selector: 'app-contact',
    templateUrl: './conctact.component.html',
    styleUrls: ['./contact.component.scss'],
    changeDetection: ChangeDetectionStrategy.OnPush,
    imports: [
        MatCardHeader,
        MatCard,
        MatCardContent,
        MatCardActions,
        MatButton,
        MatCardSubtitle,
        MatCardTitle
    ],
    standalone: true
})
export class ContactComponent implements OnInit {
    public contacts$!: Observable<ContactModel[]>;

    constructor(private _contactService: ContactService) { }

    public ngOnInit(): void {
        this.contacts$ = this._contactService.getContacts();
    }


}

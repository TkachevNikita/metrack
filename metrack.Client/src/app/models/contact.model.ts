import {IContact} from "../interfaces/contact.interface";

export class ContactModel {
    public readonly id: string;
    public readonly name: string;
    public readonly createdAt: string;
    public readonly phone: string;
    public readonly email: string;
    public readonly photo: string;

    constructor(contact: IContact) {
        this.id = contact.id!;
        this.name = contact.name;
        this.createdAt = contact.createdAt;
        this.phone = contact.phone;
        this.email = contact.email;
        this.photo = contact.photo;
    }
}

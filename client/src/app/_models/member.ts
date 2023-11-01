
import { Address } from "./address";
import { phoneNumber } from "./phone";



export interface Member {
    id: number;
    userName: string;
    email: string;
    dateOfBirth: string;
    addressStreet: string;
    phoneNumberNumber: string;
    PhoneNumbers: phoneNumber[];
    Addresses: Address[];

  }
  

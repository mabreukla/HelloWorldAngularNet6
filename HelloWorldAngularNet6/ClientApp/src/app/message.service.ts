import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class MessageService {
  // Fields
  messages: string[] = [];

  // Ctor
  constructor() { }

  // Methods
  add(message: string) {
    this.messages.push(message);
  }

  clear() {
    this.messages = [];
  }
}

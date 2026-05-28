// src/services/book.ts

import { BookData, alliesData, germansData } from '../data/books';

export class Book {
  private data: BookData;

  constructor(data: BookData) {
    this.data = data;
  }

  static loadAllies(): Book {
    return new Book(alliesData);
  }

  static loadGermans(): Book {
    return new Book(germansData);
  }

  lookup(maneuver: string, page: number): string {
    return this.data[maneuver]?.[page]?.toString() || '';
  }

  lookupInt(maneuver: string, page: number): number {
    const val = this.data[maneuver]?.[page];
    return val ?? 0;
  }

  lookupBool(maneuver: string, page: number): boolean {
    const val = this.lookup(maneuver, page);
    return val.toLowerCase() === 'true';
  }

  lookupPage(maneuver: string, page: number): number {
    return this.lookupInt(maneuver, page);
  }
}
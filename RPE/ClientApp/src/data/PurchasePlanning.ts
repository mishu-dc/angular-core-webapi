import { Entity } from "./entity";

export class PurchasePlanning {
  id: number;
  priority: number;
  priorityImgUrl: string;
  fiscalYear: number;
  division: Entity;
  description: string;
  vendor: string;
  can: Entity;
  canDescription: string;
  objectClass: string;
  planedAmount: number;
  purchaseDate: string;
  status: string;
  notes: string;
  isTag: boolean;
  tagImgUrl: string;
}

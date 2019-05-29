import { PurchasePlanning } from "./purchasePlanning";

export class PurchasePlanningResponse {
  totalCount: number;
  totalAmount: number;
  plannings: PurchasePlanning[];
}

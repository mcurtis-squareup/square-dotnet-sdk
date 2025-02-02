
# Loyalty Program Accrual Rule

Defines an accrual rule, which is how buyers can earn points.

## Structure

`LoyaltyProgramAccrualRule`

## Fields

| Name | Type | Tags | Description |
|  --- | --- | --- | --- |
| `AccrualType` | [`string`](../../doc/models/loyalty-program-accrual-rule-type.md) | Required | The type of the accrual rule that defines how buyers can earn points. |
| `Points` | `int?` | Optional | The number of points that<br>buyers earn based on the `accrual_type`.<br>**Constraints**: `>= 1` |
| `VisitData` | [`Models.LoyaltyProgramAccrualRuleVisitData`](../../doc/models/loyalty-program-accrual-rule-visit-data.md) | Optional | Represents additional data for rules with the `VISIT` accrual type. |
| `SpendData` | [`Models.LoyaltyProgramAccrualRuleSpendData`](../../doc/models/loyalty-program-accrual-rule-spend-data.md) | Optional | Represents additional data for rules with the `SPEND` accrual type. |
| `ItemVariationData` | [`Models.LoyaltyProgramAccrualRuleItemVariationData`](../../doc/models/loyalty-program-accrual-rule-item-variation-data.md) | Optional | Represents additional data for rules with the `ITEM_VARIATION` accrual type. |
| `CategoryData` | [`Models.LoyaltyProgramAccrualRuleCategoryData`](../../doc/models/loyalty-program-accrual-rule-category-data.md) | Optional | Represents additional data for rules with the `CATEGORY` accrual type. |

## Example (as JSON)

```json
{
  "accrual_type": "ITEM_VARIATION",
  "points": 236,
  "visit_data": {
    "minimum_amount_money": {
      "amount": 24,
      "currency": "GEL"
    },
    "tax_mode": "BEFORE_TAX"
  },
  "spend_data": {
    "amount_money": {
      "amount": 248,
      "currency": "MXV"
    },
    "excluded_category_ids": [
      "excluded_category_ids4"
    ],
    "excluded_item_variation_ids": [
      "excluded_item_variation_ids3",
      "excluded_item_variation_ids4"
    ],
    "tax_mode": "BEFORE_TAX"
  },
  "item_variation_data": {
    "item_variation_id": "item_variation_id0"
  },
  "category_data": {
    "category_id": "category_id4"
  }
}
```


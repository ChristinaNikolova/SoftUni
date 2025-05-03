terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "4.12.0"
    }
  }
}

provider "azurerm" {
  subscription_id = "8c6b5631-6453-4b9c-886e-7cbd156191f0"
  features {
  }
}

resource "random_integer" "ri" {
  min = 10000
  max = 99999
}

resource "azurerm_resource_group" "arg" {
  name     = "ContactBookRG${random_integer.ri.result}"
  location = "West Europe"
}

resource "azurerm_service_plan" "asp" {
  name                = "contact-book-${random_integer.ri.result}"
  location            = azurerm_resource_group.arg.location
  resource_group_name = azurerm_resource_group.arg.name
  os_type             = "Linux"
  sku_name            = "F1"
}

resource "azurerm_linux_web_app" "alwa" {
  name                = "contact-book-wb-app-${random_integer.ri.result}"
  location            = azurerm_service_plan.asp.location
  resource_group_name = azurerm_resource_group.arg.name
  service_plan_id     = azurerm_service_plan.asp.id

  site_config {
    application_stack {
      node_version = "16-lts"
    }
    always_on = false
  }
}

resource "azurerm_app_service_source_control" "aassc" {
  app_id   = azurerm_linux_web_app.alwa.id
  repo_url = "https://github.com/nakov/ContactBook"
  branch   = "master"
  use_manual_integration = true
}
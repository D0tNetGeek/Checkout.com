<h1>Shopping Cart API</h1>

Current Api Version: 1.0

<h2>Solution</h2>

</hr>
This test consists of the following projects:

<ul>
<li><strong>Checkout.BusinessLogic</strong></li>
Contains business logic for services and repositories responsible for data operations, such as retrieving and saving data;</br></br>

<li><strong>Checkout.BusinessLogic.Tests</strong></li><br>
Unit tests for Checkout.Application;

<li><strong>Checkout.EF</strong></li><br>
Contains database configuration (such as model indexes or complex keys) and initialsation i.e. seed data. It is worth noting this prototype uses an In Memory representation of the database;

<li><strong>Checkout.Models</strong></li><br>
Contains entity definitions which describe the structures in which data can be saved, i.e. tables;

<li><strong>Checkout.Web</strong></li><br>
The core WebApi application, containing REST API controller Endpoints for countries, products and cart management;

<li><strong>Checkout.Web.Client</strong></li><br>
Contains generated client library code, based off nswag.json configuration file. Examples are available in CSharp and Typescript;

<li>C<strong>heckout.Web.Console</strong></li><br>
Provides a real world example of how to use the CSharp client library code in Checkout.Web.Client. The file Program.cs demonstrates how to use the Client Library and has examples of each endpoint usage.

<li><strong>Checkout.Web.Tests</strong></li><br>
Unit tests for Checkout.Web.
</ul>

<h2>Setup</h2>
<p>NodeJS must be installed on your system.</p>

<p>Clone or download this repository to your local machine. Then click the file Checkout.com.sln file, this should open the solution correctly whereby you will be presented with an N-layer solution.

Ensure you set the Startup project to Checkout.Web. Restore all Nuget and npm packages, then, right click the solution icon and select BUILD.</p>

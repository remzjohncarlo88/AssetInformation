* AssetInfoDB.sql is the database copy it contains schema and sample data.

*  Design
*  > It is a layered pattern which consists of Models, Controllers, Data(Context), Services, and Repositories.
   > The entire solution both the main API project and test project implement Dependecy Injection via constructor.

*  Assumptions
*  > Created three database tables consisting of Sources, Assets, and AssetSourcePrice.
   > The AssetSourcePrice is the conjunction table whil will hold the prices as they come.

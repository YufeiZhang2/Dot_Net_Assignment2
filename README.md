# Smart-Weather-Forecasting
This is the assignment 2 for .Net Enterprise Development
This application is built by using ASP.NET MVC, Entity Framework and LocalDB.

-------------------------------------------------------------------------------------------
Functionality:

•	Everyone (including users who aren't logged in):

○ Enter text and see response from weather forecasting

•	All users with an account:

○ Log in 
○ Change password 

•	Data maintainers:

○ Create, edit, delete rows in the database table 
○ See the name of the last user who created/edited a particular row in the database table

•	Editors:

○ Create conversational rules (fixed rules and data-driven rules) for weather forecasting
○ Edit or delete conversational rules that have not yet been approved or rejected 
○ See a list of all rules that have not yet been approved or rejected 
○ See a list of all rules that have been rejected (once rejected, the rule can't be edited or deleted) 
○ Run a report that shows (on just one report):

■ The list of individual rules that the current user has created or edited and which have been approved 
■ The total count of approved rules that they were responsible for
■ The total count of rejected rules that they were responsible for 
■ A percentage success rate: #approved / (#approved + #rejected) 

•	Approver: 

See the details of all rules that have not yet been approved or rejected, and who was the last person to create or edit the rule 

Approve a conversational rule Reject a conversational rule (once rejected, the rule can't be edited or deleted by anyone) Run a report that shows:

■ The list of individual rules which have been approved
■ The total count of approved rules 
■ The total count of rejected rules 
■ A percentage success rate: #approved / (#approved + #rejected) Run a report that shows:

■ For each Editor, their total count of approved rules 
■ For each Editor, their total count of rejected rules 
■ For each Editor, their total count of rules that have not yet been approved or rejected 
■ For each Editor, their percentage success rate: #approved / (#approved + #rejected) 
■ An average success rate

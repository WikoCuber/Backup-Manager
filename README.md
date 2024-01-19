# Introduction
Backup Manager allows to do copy of chosen items in chosen directory

# Technologies used
 - .NET 8
 - Windows Froms

# Features
 - Creating backup of your data
 - Fast updating your copy

# Getting Started
To use this app you need .NET 8 Desktop Runtime. You can download this from [here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or open an app (if you don't have installed runtime you will get a message with link to download). 

# Usage
On the left side is the panel that shows yours chosen items. 

![chosen elements](https://github.com/WikoCuber/Backup-Manager/assets/98224818/54b3fcd5-9489-44bd-a713-8051c5d2339e) 

To add item just click on one of the buttons bellow. To delete item, select it and click delete key.

![add buttons](https://github.com/WikoCuber/Backup-Manager/assets/98224818/046a5408-9508-4f8d-95e2-5da7faa39903)

If you select item in panel and the item is a directory, on the right side you will see subelements.

![subelements](https://github.com/WikoCuber/Backup-Manager/assets/98224818/95f3102f-3fc6-4a7f-9736-e13c4d4a4c02)

You can choose white or black list (black list is when the white list checkbox is unchecked) and select items that you need.

![white list](https://github.com/WikoCuber/Backup-Manager/assets/98224818/1d8857d7-e19c-4efc-bbaa-484392db007b)

Under the make copy button are two checkboxes. First indicate whether program have to check size of files before actual copy them. Second indicate whether program have to delete files from copy directory that not belonging to copy.

![checkboxes](https://github.com/WikoCuber/Backup-Manager/assets/98224818/c25b69b3-e630-466a-98dd-afc9730079ca)

To make copy click make copy button and wait a moment. After this select copy directory and click start button.

![copy form](https://github.com/WikoCuber/Backup-Manager/assets/98224818/b0027e37-48f2-44d9-b1cb-8f558c4532de)

# License
Distributed under the GNU GPL v3.0 License. See LICENSE.txt for more information.

# Save File
Your saved options and selected items are stored in %appdata%/Backup Manager/save.json file.

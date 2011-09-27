CREATE TABLE 
    "EventInfo" (
        "Id" INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL , 
        "WindowTitle" VARCHAR(250), 
        "EventDate" DATETIME DEFAULT CURRENT_TIMESTAMP, 
        "EventType" VARCHAR(50)
    )
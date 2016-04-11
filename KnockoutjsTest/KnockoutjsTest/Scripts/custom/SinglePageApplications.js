function WebmailViewModel() {

    Sammy(function () {
        this.get('#:folder', function () {
            var folder = this.params.folder;
            self.chosenFolderId(folder);
            self.chosenMailData(null);
            var jsonFile = folder + '.json';
            //$.get('/mail', { folder: folder }, self.chosenFolderData);
            $.getJSON("../../Content/Json/" + jsonFile, function (data) {
                self.chosenFolderData(data);
            });
        });

        this.get('#:folder/:mailId', function () {
            self.chosenFolderId(this.params.folder);
            self.chosenFolderData(null);
            $.getJSON("/api/mail/" + this.params.mailId, function (data) {
                self.chosenMailData(data);
            });
        });

        this.get('', function () {
            this.app.runRoute('get','#Inbox');
        });

    }).run();

    var self = this;
    self.folders = ['Inbox', 'Archive', 'Sent', 'Spam'];

    self.chosenFolderId = ko.observable();
    self.chosenFolderData = ko.observable();
    self.chosenMailData = ko.observable();

    self.goToFolder = function (folder) {
        location.hash = folder;
    };

    self.goToMail = function (mail) {
        location.hash = mail.folder + '/' + mail.id;
    };

    // Use the way of local static JSON file
    self.goToMail2 = function (mail) {
        self.chosenFolderId(mail.folder);
        self.chosenFolderData(null);
        $.getJSON("../../Content/Json/Mails.json", function (data) {
            var resultItem = data.find(function (item) {
                return item.id === mail.id;
            });
            self.chosenMailData(resultItem);
        });

    };

    self.testData = function () {
        var deferred = $.Deferred();

        deferred.then(function (data) {
            console.log(data);
            console.log("This is the first callBack");
        });
        deferred.resolve(true);

    };

    //self.goToFolder("Inbox");
}

ko.applyBindings(new WebmailViewModel());

//REGIST A NEW FUNCTION TO ARRAY NAMED FOUND
//if (!Array.prototype.find) {
//    Array.prototype.find = function (predicate) {
//        if (this === null) {
//            throw new TypeError('Array.prototype.find called on null or undefined');
//        }
//        if (typeof predicate !== 'function') {
//            throw new TypeError('predicate must be a function');
//        }
//        var list = Object(this);
//        var length = list.length >>> 0;
//        var thisArg = arguments[1];
//        var value;

//        for (var i = 0; i < length; i++) {
//            value = list[i];
//            if (predicate.call(thisArg, value, i, list)) {
//                return value;
//            }
//        }
//        return undefined;
//    };
//}
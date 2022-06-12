import random
import string
from datetime import datetime, timedelta

def generateRandomUsername(number) -> list:
    lst = []
    with open('users.txt', 'r', encoding='utf8') as f:
        for username in f:
            lst.append(username.replace('\n', ''))
    return random.sample(list(set(lst)), number)


def generateRandomEmail(number) -> list:
    emailDomains = ["hotmail.com", "gmail.com", "aol.com", "mail.com", "mail.kz", "yahoo.com", "ua.pt"]
    alpha = list(string.ascii_letters)
    digit = list(string.digits)
    special = ['.', '-', '_']
    letters = alpha + digit + special
    lst = []

    def get_one_random_domain():
        return random.choice(emailDomains)

    def get_one_random_name():
        email_name = ''.join(random.choice(alpha))
        for i in range(random.randint(0, 22)):
            gen = random.choice(letters)
            if not (gen in special and email_name[-1] in special):
                email_name = email_name + random.choice(letters)
        if email_name[-1] in special:
            email_name = email_name[:-1]
        return email_name

    for email in range(0, number):
        one_name = str(get_one_random_name())
        one_domain = str(get_one_random_domain())
        lst.append(one_name + "@" + one_domain)

    return lst

def generateRandomPassword(number) -> list:
    lst = []
    lower = string.ascii_lowercase
    upper = string.ascii_uppercase
    num = string.digits
    symbols = string.punctuation
    # string.ascii_letters

    # combine the data
    allSymbols = lower + upper + num + symbols

    for i in range(0, number):
        # use random
        temp = random.sample(allSymbols, random.randint(4, 22))

        # create the password
        password = "".join(temp)

        lst.append(password)
    return lst

def generateRandomDate(number, min_year=1970) -> list:
    max_year = datetime.now().year
    lst = []

    for i in range(0, number):

        decider = random.randint(0, 100)
        if decider > 20:
            # generate a datetime in format yyyy-mm-dd
            start = datetime(min_year, 1, 1, 00, 00, 00)
            years = max_year - min_year + 1
            end = start + timedelta(days=365 * years)
            date = (start + (end - start) * random.random()).strftime('%Y-%m-%d')
        else:
            date = None
        lst.append(date)

    return lst

def generateRandomRegion() -> str:
    regions = ['World', 'Europe', 'Turkey', 'South America', 'North America', 'Sub-Saharan Africa', 'Oceania',
               'North Africa', 'Middle East', 'Korea', 'China', 'Brazil', 'Asia-Pacific South', 'Asia-Pacific North']
    return random.choice(regions)

def generateRandomGender() -> str:
    genders = ['F', 'M']
    decider = random.randint(0, 100)
    return random.choice(genders) if decider > 20 else None

def generateUser(number) -> list[list]:

    users = []
    usernames = generateRandomUsername(number)
    passwords = generateRandomPassword(number)
    emails = generateRandomEmail(number)
    birthdays = generateRandomDate(number)
    joindates = generateRandomDate(number, min_year=2016)

    for i in range(0, number):
        user = [usernames[i], passwords[i], birthdays[i], emails[i], generateRandomRegion(), joindates[i], generateRandomGender()]
        users.append(user)

    return users

print(generateUser(10))



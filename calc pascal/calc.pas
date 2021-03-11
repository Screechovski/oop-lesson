//fpc 3.0.4

program HelloWorld;

var 
    line: string;
    numArr: array[1..30] of integer;    
    operArr: array[1..30] of string;
    iLine: integer; // inde for line
    iOper: integer; // index for operArr (+-*/)
    iNum: integer; // index for numArr
    lastOperation: integer; // index last +-/*
    loopOperAdded: boolean; // flag add +-*/ in operArr
    loopNumAdded: boolean; // flag add num for numArr
    lastNumber: boolean;
    localNumber: string;

begin
    line:='5/3+5*2-2';
    lastOperation:=1;
    loopOperAdded:=false;
    loopNumAdded:=false;
    
    
    for iLine:= 1 to length(line) do
    begin
        if (line[iLine] = '+') or (line[iLine] = '-') or (line[iLine] = '*') or (line[iLine] = '/') or (iLine=length(line)) then
        begin
			// check for current elemnt is last
            if (iLine=length(line)) then
            begin
				// if last add this element
                localNumber:= copy(line, lastOperation, iLine);
            end
            else 
            begin
				// if does not add this element-1
                localNumber:= copy(line, lastOperation, iLine-lastOperation);
                lastOperation:=iLine+1;
            end;       
            // add num in numArr
            loopNumAdded:=true;
            for iNum:= 1 to length(numArr) do
            begin
                if (numArr[iNum] = 0) and (loopNumAdded) then 
                begin
                    loopNumAdded:=false;
                    numArr[iNum]:=StrToInt(localNumber);
                end;                
            end;
            // add oper (+-*/) in operArr
            loopOperAdded:=true;
            for iOper:= 1 to length(operArr) do
            begin
                if (operArr[iOper] = '') and (loopOperAdded) and (iLine<>length(line)) then 
                begin
                    operArr[iOper]:=line[iLine];
                    loopOperAdded:=false;
                end;
            end;
        end
        else
        begin
            //writeln(line[iLine] + ' number');
        end;
    end;
    for iLine:= 1 to length(operArr) do
    begin
        writeln(operArr[iLine]);
    end;
    for iLine:= 1 to length(numArr) do
    begin
        writeln(numArr[iLine]);
    end;
    (*writeln(copy(line, 0, 3));
    writeln(line);*)
end.
